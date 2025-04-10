//
//  CorrectionViewController.swift
//  JPDict
//
//  Created by LunA on 5/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import UIKit

class CorrectionViewController: UIViewController {
    
    @IBOutlet weak var engLabel: UILabel!
    @IBOutlet weak var qNumLabel: UILabel!
    
    @IBOutlet weak var hiraTF: UITextField!
    @IBOutlet weak var kanjiTF: UITextField!
    
    @IBOutlet weak var nextBtn: UIButton!
    @IBOutlet weak var prevBtn: UIButton!
    @IBOutlet weak var homeBtn: UIButton!

    var dict = Dictation()

    override func viewDidLoad() {
        super.viewDidLoad()
        update()
    }

    
    func update(){
        engLabel.text = dict.getQuestion()
        qNumLabel.text = String(dict.getCurrQNum()) + "/" + String(dict.getSize())
        
        if dict.reachLastQuestion(){nextBtn.isHidden = true}
        else{nextBtn.isHidden = false}
        if dict.atFirstQuestion(){prevBtn.isHidden = true}
        else{prevBtn.isHidden = false}
        
        hiraTF.text = dict.getHira()
        kanjiTF.text = dict.getKanji()
        hiraTF.isEnabled = false
        kanjiTF.isEnabled = false
    }
    
    @IBAction func next(){
        dict.next()
        update()
    }
    
    @IBAction func prev(){
        dict.prev()
        update()
    }
    
    @IBAction func tapHome(_ sender: Any) {
        navigationController?.popToRootViewController(animated: true)
    }
    
    // Disable dark mode
    class ViewController: UIViewController {
        override func viewDidLoad() {
            super.viewDidLoad()
            overrideUserInterfaceStyle = .light
        }
    }
}
