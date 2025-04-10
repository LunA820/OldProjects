//
//  RecordManager.swift
//  JPDict
//
//  Created by LunA on 6/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import Foundation
import UIKit
import CoreData

class RecordManager{
    // Connect & Access Database
    let context = (UIApplication.shared.delegate as! AppDelegate).persistentContainer.viewContext
    let request = NSFetchRequest<NSFetchRequestResult>(entityName: "Custom")
    
    init(){
        request.returnsObjectsAsFaults = false
    }
    
    
    /**
        Edit score (progress) of a specific unit
     */
    func editProgress(unit: String, score: String){
    
        var saveFlag = false
       
        do{
            let result = try context.fetch(request)
            
            for data in result as! [NSManagedObject]{
                let u = data.value(forKey: "unit") as! String
                
                if u == unit{
                    data.setValue(score, forKey: "progress")
                    do{
                        try context.save()
                        saveFlag = true
                        print("Progress Edited!")
                    }catch{
                        print("Failed editing!")
                    }
                                       
                }
            }
        } catch {
            print("Load error!")
        }
        
        
        // If record does not exist, create a new record
        if saveFlag == false{
            // Set new Entity of progress
            let entity = NSEntityDescription.entity(forEntityName: "ProgressRecords", in: context)
            let newEntity = NSManagedObject(entity: entity!, insertInto: context)
                        
            newEntity.setValue(score, forKey: "progress")
            newEntity.setValue(unit, forKey: "unit")
            
            // Save result
            do{
                try context.save()
                print("Saved!")
            }catch{
                print("Failed saving!")
            }
        }
    }

    func toPercentage(score: String)->String{
        return " " + score + "%"
    }
}
