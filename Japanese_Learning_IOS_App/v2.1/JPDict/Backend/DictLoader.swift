//
//  Dictation.swift
//  JPDict
//
//  Created by LunA on 4/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import Foundation
import UIKit
import CoreData

/**
    DictLoader read a file and breakdown the contents into a list of Question Objects.
 */
class DictLoader{
    private var questionBank: [Question]
    private var size: Int
    
    init(chapter: String){
        questionBank = []
        size = 0
        
        // Append an empty vocab if it's the custom Dict
        if chapter == "custom"{
            loadCustomDict()
        }
        else{
            setQuestionBank(chapter: chapter)
        }
    }
    
    private func setQuestionBank(chapter: String){
        let path = Bundle.main.path(forResource: chapter, ofType: "txt")

        do{
            // Read data into a buffer array line by line
            let data = try String(contentsOfFile: path!, encoding: String.Encoding.utf8)
            let buffer = data.components(separatedBy: .newlines)
                  
            // Append each line as a vocab in vocabList
            for item in buffer{
                if item != ""{
                    let vocab = item.components(separatedBy: ".")
                    questionBank.append(Question(eng: vocab[0], hira: vocab[2], kanji: vocab[1]))
                    size += 1
                }
            }
        } catch let error as NSError{
            print(error)
        }
    }
    
    
    
    func loadCustomDict(){
        let context = (UIApplication.shared.delegate as! AppDelegate).persistentContainer.viewContext
        let request = NSFetchRequest<NSFetchRequestResult>(entityName: "Custom")
        request.returnsObjectsAsFaults = false
        
        do{
            let vocabs = try context.fetch(request)
            
            for v in vocabs as! [NSManagedObject]{
                let e = v.value(forKey: "english") as! String
                let h = v.value(forKey: "hiragana") as! String
                let k = v.value(forKey: "kanji") as! String
                
                questionBank.append(Question(eng: e, hira: h, kanji: k))
                size += 1
            }
        } catch {
            print("Load error!")
        }
    }
    

    func getQuestionBank()->[Question]{return questionBank}
    func getSize()->Int{return size}
}
