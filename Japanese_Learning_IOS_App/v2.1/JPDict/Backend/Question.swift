//
//  Question.swift
//  JPDict
//
//  Created by LunA on 4/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import Foundation

public class Question{
    private var vocab: Vocab
    private var ans: Vocab
    
    init (eng: String, hira: String, kanji: String){
        vocab = Vocab(eng: eng, hira: hira, kan: kanji)
        ans = Vocab(eng: eng, hira: "", kan: "")
    }
    
    func mark()->Int{
        if (vocab.getHira() != ans.getHira()){return 0}
        if (vocab.getKan() != ans.getKan()){return 0}
        return 1
    }
    
    func setAns(hira: String, kanji: String){
        ans.setHira(h: hira)
        ans.setKanji(k: kanji)
    }
    
    func getQuestion()->String{return vocab.getEng()}
    func getHira()->String{return vocab.getHira()}
    func getKanji()->String{return vocab.getKan()}
    
    func alreadyExist(eng: String, hira: String, kanji: String)->Bool{
        if vocab.getEng() == eng{
            if vocab.getHira() == hira && vocab.getKan() == kanji{
                return true
            }
        }
        return false
    }
}
