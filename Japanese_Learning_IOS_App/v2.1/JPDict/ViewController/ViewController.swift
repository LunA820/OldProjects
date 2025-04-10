//
//  ViewController.swift
//  JPDict
//
//  Created by LunA on 4/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import UIKit

class ViewController: UIViewController {


    override func viewDidLoad() {
        super.viewDidLoad()
    }

    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if segue.identifier! == "progress"{
            _ = segue.destination as! ProgressViewController
        }
            
        else if segue.identifier! == "custom"{
            let vc = segue.destination as! CustomViewController
            let cm = CustomManager()
            
            // If customVocab is empty, enter dictionary mode
            // else creation mode
            vc.dictMode = !(cm.isEmpty())
        }
            
        else{
            let vc = segue.destination as! ChViewController
            vc.mode = String(segue.identifier!)
        }
    }
    
}

