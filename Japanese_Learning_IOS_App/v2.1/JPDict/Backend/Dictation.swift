//
//  Dictation.swift
//  JPDict
//
//  Created by LunA on 4/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import Foundation

class Dictation{
    // Variables & Constructor
    var questionBank: [Question]
    var itr: Int
    var size: Int
    
    init(){
        questionBank = []
        itr = 0
        size = 0
    }
    
    // Setters
    func setQuestionBank(chapter: String){
        let qLoader = DictLoader(chapter: chapter)
        questionBank = qLoader.getQuestionBank()
        size = qLoader.getSize()
    }
    
    func addQuestion(q: Question){
        questionBank.append(q)
        size += 1
    }
    
    func setAns(hiragana: String, kanji: String){
        questionBank[itr].setAns(hira: hiragana, kanji: kanji)
    }
    
    // Getters
    func getQuestion()->String{return questionBank[itr].getQuestion()}
    func getHira()->String{return questionBank[itr].getHira()}
    func getKanji()->String{return questionBank[itr].getKanji()}
    func getSize()->Int{return size}
    func getCurrQNum()->Int{return itr+1}
    
    
    // Results & Corrections
    /**
        Calculate final score of the dictation
        - Returns: Percentage score in string
     */
    func calScore()->String{
        var ans = 0
        for q in questionBank{
            ans += q.mark()
        }
        return String(ans*100/size)
    }
    
    /**
        Create a new correction dictation contains all questions answered wrong
         - Returns: Dictation object
     */
    func genCorrection()->Dictation{
        let d = Dictation()
        for q in self.questionBank{
            if q.mark() == 0 {
                d.addQuestion(q: q)
            }
        }
        return d
    }
    
    
    /**
     Check if the current question is answered correctly
     */
    func mark()->Bool{
        if questionBank[itr].mark() == 1 {return true}
        return false
    }
    
    
    
    // Iterator functions
    func next(){
        if(itr >= size-1){return}
        itr += 1
    }
    
    func prev(){
        if(itr == 0){return}
        itr -= 1
    }
    
    func reachLastQuestion()->Bool{return itr == size-1}
    func atFirstQuestion()->Bool{return itr==0}
    func goFirstQuestion(){itr = 0}
    
    func vocabAlreadyExist(eng: String, hira: String, kanji: String)->Bool{
        for q in questionBank{
            if q.alreadyExist(eng: eng, hira: hira, kanji: kanji){
                return true
            }
        }
        return false
    }
}
