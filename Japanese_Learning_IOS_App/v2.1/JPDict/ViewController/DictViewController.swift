//
//  DictViewController.swift
//  JPDict
//
//  Created by LunA on 5/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import UIKit

class DictViewController: UIViewController {
    @IBOutlet weak var chapterLabel: UILabel!
    @IBOutlet weak var engLabel: UILabel!
    @IBOutlet weak var qNumLabel: UILabel!
    
    @IBOutlet weak var hiraTF: UITextField!
    @IBOutlet weak var kanjiTF: UITextField!
    
    @IBOutlet weak var submitBtn: UIButton!
    @IBOutlet weak var nextBtn: UIButton!
    @IBOutlet weak var prevBtn: UIButton!
    @IBOutlet weak var finBtn: UIButton!
    
    var mode = String()
    var chapter = String()
    var dict = Dictation()

    override func viewDidLoad() {
        super.viewDidLoad()
        dict.setQuestionBank(chapter: chapter)
        if mode == "Dictionary"{submitBtn.isHidden = true}
        
        if chapter == "custom"{
            chapterLabel.text = "Custom"
        }
        else{
            chapterLabel.text = "Chapter " + chapter
        }

        update()
    }

    
    func update(){
        engLabel.text = dict.getQuestion()
        qNumLabel.text = String(dict.getCurrQNum()) + "/" + String(dict.getSize())
        
        if dict.reachLastQuestion(){
            nextBtn.isHidden = true
            finBtn.isHidden = false
        }
        else{
            nextBtn.isHidden = false
            finBtn.isHidden = true
        }
        
        if dict.atFirstQuestion(){prevBtn.isHidden = true}
        else{prevBtn.isHidden = false}
        
        if mode == "Dictionary"{
            displayAns()
            finBtn.isHidden = true
            hiraTF.isEnabled = false
            kanjiTF.isEnabled = false
            return
        }
        resetAnsArea(mark: dict.mark())
    }
    
    func resetAnsArea(mark: Bool){
        if(!mark){
            // Set button appearance
            submitBtn.setImage(UIImage(systemName: "checkmark.shield.fill"), for: UIControl.State.normal)
            
            submitBtn.tintColor = UIColor.black
            submitBtn.isEnabled = true
            
            // Reset textField appearance
            hiraTF.text = nil
            kanjiTF.text = nil
            hiraTF.placeholder = "Hiragana/Katakana"
            kanjiTF.placeholder = "Kanji"
            hiraTF.isEnabled = true
            kanjiTF.isEnabled = true
        }
        else{
            submitBtn.tintColor = UIColor.green
            submitBtn.isEnabled = false
            
            // Set Textfield and disable Textfield
            displayAns()
            hiraTF.placeholder = nil
            kanjiTF.placeholder = nil
            
            hiraTF.isEnabled = false
            kanjiTF.isEnabled = false
        }
    }
    
    
    @IBAction func submit(){
        let h = hiraTF.text
        let k = kanjiTF.text
        if h != nil && k != nil {dict.setAns(hiragana: h!, kanji: k!)}
        
        if(dict.mark()){
            submitBtn.tintColor = UIColor.green
            submitBtn.setImage(UIImage(systemName: "checkmark.shield.fill"), for: UIControl.State.normal)
        }
        else{
            submitBtn.tintColor = UIColor.red
            submitBtn.setImage(UIImage(systemName: "xmark.shield.fill"), for: UIControl.State.normal)
        }
    }
    
    @IBAction func next(){
        dict.next()
        update()
    }
    
    @IBAction func prev(){
        dict.prev()
        update()
    }
    
    func displayAns(){
        hiraTF.text = dict.getHira()
        kanjiTF.text = dict.getKanji()
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let vc = segue.destination as! ResultViewController
        vc.score = dict.calScore()
        vc.correction = dict.genCorrection()
    }
    
    @IBAction func recordScore(){
        if chapter == "custom"{return}
        else{
            let rm = RecordManager()
            let s = rm.toPercentage(score: dict.calScore())
            rm.editProgress(unit: chapter, score: s)
        }
    }
    
    // Hide keyboard if touching outside
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        self.view.endEditing(true)
    }

    // Disable autorotate
    override var shouldAutorotate: Bool{
        return false
    }
    
    // Disable dark mode
    class ViewController: UIViewController {
        override func viewDidLoad() {
            super.viewDidLoad()
            overrideUserInterfaceStyle = .light
        }
    }
}
