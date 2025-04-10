//
//  CustomViewController.swift
//  JPDict
//
//  Created by LunA on 7/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import UIKit
import CoreData

class CustomViewController: UIViewController {
    @IBOutlet weak var qNumLabel: UILabel!
    
    @IBOutlet weak var engTF: UITextField!
    @IBOutlet weak var hiraTF: UITextField!
    @IBOutlet weak var kanjiTF: UITextField!
    
    @IBOutlet weak var createBtn: UIButton!
    @IBOutlet weak var delBtn: UIButton!
    @IBOutlet weak var prevBtn: UIButton!
    @IBOutlet weak var nextBtn: UIButton!
    @IBOutlet weak var dictBtn: UIButton!

    
    var dict = Dictation()
    var dictMode = Bool()
    var cm = CustomManager()
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        if dictMode == false{
            setCreateInterface()
        }
        else{
            dict.setQuestionBank(chapter: "custom")
            setDictInterface()
        }
        
    }

    func setCreateInterface(){
        // Hide all buttons except createBtn
        delBtn.isHidden = true
        dictBtn.isHidden = true
        nextBtn.isHidden = true
        prevBtn.isHidden = true
        
        // Set Interface
        qNumLabel.text = "Add New Vocab"
        createBtn.setTitle(" SAVE", for: .normal)
        enableTextFields()
    }
    
    func setDictInterface(){
        // Show question numbers, Prev button & Next button
        delBtn.isHidden = false
        dictBtn.isHidden = false
        nextBtn.isHidden = dict.reachLastQuestion()
        prevBtn.isHidden = dict.atFirstQuestion()
        
        // Display vocab
        qNumLabel.text = String(dict.getCurrQNum()) + "/" + String(dict.getSize())
        createBtn.setTitle("Create", for: .normal)
        displayVocab()
        disableTextFields()
    }
    
    
    @IBAction func createVocab(){
        // If in dict mode, go to creation page
        if dictMode{
            dictMode = false
            setCreateInterface()
        }
        
        // If at creation page, read input and create vocab
        else{
            // If there is no inputs, return
            let eInput = engTF.text
            let hInput = hiraTF.text
            let kInput = kanjiTF.text
            if eInput == "" || hInput == ""{return}
            
            // If the vocab already exists, return
            if cm.alreadyExist(eng: eInput!, hira: hInput!, kanji: kInput!){
                dictMode = true
                setDictInterface()
                return
            }
            
            // Create new vocab, update interface
            cm.createVocab(eng: eInput!, hira: hInput!, kanji: kInput!)
            dictMode = true
            dict.setQuestionBank(chapter: "custom")
            setDictInterface()
        }
    }
    
    @IBAction func delVocab(){
        cm.delVocab(eng: engTF.text!, hira: hiraTF.text!, kanji: kanjiTF.text!)
        
        if !cm.isEmpty(){
            dict.setQuestionBank(chapter: "custom")
            dict.goFirstQuestion()
            setDictInterface()
        }
        
        else{
            dictMode = false
            setCreateInterface()
        }
    }
    
    @IBAction func next(){
        dict.next()
        setDictInterface()
    }
    
    @IBAction func prev(){
        dict.prev()
        setDictInterface()
    }
    
    
    
    /**
        Enable all textfields
     */
    func enableTextFields(){
           engTF.text = nil
           hiraTF.text = nil
           kanjiTF.text = nil
           engTF.placeholder = "English"
           hiraTF.placeholder = "Hiragana/Katakana"
           kanjiTF.placeholder = "Kanji"
           engTF.isEnabled = true
           hiraTF.isEnabled = true
           kanjiTF.isEnabled = true
    }
    
    /**
        Disable all textfields, show Vocab at text fields.
     */
    func disableTextFields(){
        engTF.isEnabled = false
        hiraTF.isEnabled = false
        kanjiTF.isEnabled = false
    }
    
    func displayVocab(){
        engTF.text = dict.getQuestion()
        hiraTF.text = dict.getHira()
        kanjiTF.text = dict.getKanji()
    }
    
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let vc = segue.destination as! DictViewController
        vc.mode = "Dictation"
        vc.chapter = "custom"
    }
    
    // Hide keyboard if touching outside
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        self.view.endEditing(true)
    }
}
