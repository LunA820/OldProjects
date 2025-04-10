//
//  ResultViewController.swift
//  JPDict
//
//  Created by LunA on 5/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import UIKit

class ResultViewController: UIViewController {
    @IBOutlet weak var scoreLabel: UILabel!
    @IBOutlet weak var corrBtn: UIButton!
    

    var score = String()
    var correction = Dictation()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        scoreLabel.text = score + " %"
        navigationItem.hidesBackButton = true
        
        if score == "100"{
            corrBtn.isHidden = true
        }
    }

    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let vc = segue.destination as! CorrectionViewController
        vc.dict = correction
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
