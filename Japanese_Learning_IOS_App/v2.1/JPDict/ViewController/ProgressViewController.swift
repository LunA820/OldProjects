//
//  ProgressViewController.swift
//  JPDict
//
//  Created by LunA on 7/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import UIKit
import CoreData

class ProgressViewController: UIViewController {

    @IBOutlet weak var Unit1: UIButton!
    @IBOutlet weak var Unit2: UIButton!
    @IBOutlet weak var Unit3: UIButton!
    @IBOutlet weak var Unit4: UIButton!
    @IBOutlet weak var Unit5: UIButton!
    @IBOutlet weak var Unit6: UIButton!
    @IBOutlet weak var Unit7: UIButton!
    @IBOutlet weak var Unit8: UIButton!
    @IBOutlet weak var Unit9: UIButton!
    @IBOutlet weak var Unit10: UIButton!
    @IBOutlet weak var Unit11: UIButton!
    @IBOutlet weak var Unit12: UIButton!
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        loadProgress()
    }
    
    func loadProgress(){
        let context = (UIApplication.shared.delegate as! AppDelegate).persistentContainer.viewContext
        
        let request = NSFetchRequest<NSFetchRequestResult>(entityName: "ProgressRecords")
        request.returnsObjectsAsFaults = false
        
        do{
            let result = try context.fetch(request)
            for data in result as! [NSManagedObject]{
                let u = data.value(forKey: "unit") as! String
                let s = data.value(forKey: "progress") as! String
                
                if u == "1"{Unit1.setTitle(s, for: .normal)}
                else if u == "2"{Unit2.setTitle(s, for: .normal)}
                else if u == "3"{Unit3.setTitle(s, for: .normal)}
                else if u == "4"{Unit4.setTitle(s, for: .normal)}
                else if u == "5"{Unit5.setTitle(s, for: .normal)}
                else if u == "6"{Unit6.setTitle(s, for: .normal)}
                else if u == "7"{Unit7.setTitle(s, for: .normal)}
                else if u == "8"{Unit8.setTitle(s, for: .normal)}
                else if u == "9"{Unit9.setTitle(s, for: .normal)}
                else if u == "10"{Unit10.setTitle(s, for: .normal)}
                else if u == "11"{Unit11.setTitle(s, for: .normal)}
                else if u == "12"{Unit12.setTitle(s, for: .normal)}
                
            }
        } catch {
            print("Load error!")
        }
    }
    
    
    @IBAction func tapReset(){
        let context = (UIApplication.shared.delegate as! AppDelegate).persistentContainer.viewContext
        
        let request = NSFetchRequest<NSFetchRequestResult>(entityName: "ProgressRecords")
        request.returnsObjectsAsFaults = false
               
        do{
            let result = try context.fetch(request)
            for data in result as! [NSManagedObject]{
                data.setValue(" N/A", forKey: "progress")
            }
            
        } catch {
                print("Load error!")
        }
        
        
        do{
            try context.save()
            print("Saved!")
        }catch{
            print("Failed saving!")
        }
        
        loadProgress()
    }
    
}
