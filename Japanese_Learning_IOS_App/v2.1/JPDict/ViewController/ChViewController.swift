//
//  DictViewController.swift
//  JPDict
//
//  Created by LunA on 5/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import UIKit

class ChViewController: UIViewController {
    @IBOutlet weak var modeLabel: UILabel!
    var mode = String()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        if mode == "Dictionary"{
            self.title = "辞書"
        }
        if mode == "Dictation"{
            self.title = "クイズ"
        }
    }
    
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let vc = segue.destination as! DictViewController
        vc.mode = self.mode
        vc.chapter = String(segue.identifier!)
    }

}
