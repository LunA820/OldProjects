//
//  CustomManager.swift
//  JPDict
//
//  Created by LunA on 14/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//


import Foundation
import UIKit
import CoreData

class CustomManager{
    let context = (UIApplication.shared.delegate as! AppDelegate).persistentContainer.viewContext
    let request = NSFetchRequest<NSFetchRequestResult>(entityName: "Custom")
    
    init(){
        request.returnsObjectsAsFaults = false
    }
    

    func alreadyExist(eng: String, hira: String, kanji: String)->Bool{
        do{
            let result = try context.fetch(request)
            for data in result as! [NSManagedObject]{
                let e = data.value(forKey: "english") as! String
                let h = data.value(forKey: "hiragana") as! String
                let k = data.value(forKey: "kanji") as! String
                
                if e == eng && h == hira && k == kanji{
                    return true
                }
            }
        } catch {
            print("Load error!")
        }
        return false
    }
    
    
    func createVocab(eng: String, hira: String, kanji: String){
        if alreadyExist(eng: eng, hira: hira, kanji: kanji) == false{
            let entity = NSEntityDescription.entity(forEntityName: "Custom", in: context)
            let newEntity = NSManagedObject(entity: entity!, insertInto: context)
            
            // Set value of new vocab
            newEntity.setValue(eng, forKey: "english")
            newEntity.setValue(hira, forKey: "hiragana")
            newEntity.setValue(kanji, forKey: "kanji")
            
            // Save changes
            do{
                try context.save()
                print("Saved!")
            }catch{
                print("Failed saving!")
            }
        }
    }
    
    func delVocab(eng: String, hira: String, kanji: String){
        do{
            let result = try context.fetch(request)
            for data in result as! [NSManagedObject]{
                let e = data.value(forKey: "english") as! String
                let h = data.value(forKey: "hiragana") as! String
                let k = data.value(forKey: "kanji") as! String
                
                if e == eng && h == hira && k == kanji{
                    context.delete(data)
                    do{
                        try context.save()
                    }catch{
                        print("Fail to delete!")
                    }
                }
            }
        } catch {
            print("Load error!")
        }
    }
    
    func isEmpty()->Bool{
        
        do{
            let vocabs = try context.fetch(request)
            
            for v in vocabs as! [NSManagedObject]{
                let e = v.value(forKey: "english") as! String
                if e != "-1"{
                    return false
                }
            }
        } catch {
            print("Load error!")
        }
        
        return true
    }
    
}
