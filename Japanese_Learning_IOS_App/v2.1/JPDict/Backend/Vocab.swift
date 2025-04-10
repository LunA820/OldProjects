//
//  Vocab.swift
//  JPDict
//
//  Created by LunA on 4/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import Foundation


public class Vocab{
    private var english: String
    private var hiragana: String
    private var kanji: String
    
    init(eng: String, hira: String, kan: String){
        english = eng
        hiragana = hira
        kanji = kan
    }
    
    func getEng()->String{return english}
    func getHira()->String{return hiragana}
    func getKan()->String{return kanji}
    
    func setHira(h: String){hiragana = h}
    func setKanji(k: String){kanji = k}
}
