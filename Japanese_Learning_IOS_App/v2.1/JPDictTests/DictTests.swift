//
//  JPDictTests.swift
//  JPDictTests
//
//  Created by LunA on 4/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.

import XCTest
@testable import JPDict

class DictTests: XCTestCase {
    
    func testCreateDict(){
        let d = Dictation()
        d.setQuestionBank(chapter: "1")
        
        XCTAssertEqual("Home", d.getQuestion())
        d.next()
        XCTAssertEqual("Shop", d.getQuestion())
        d.setAns(hiragana: "みせ", kanji: "店")

        d.prev()
        XCTAssertEqual("Home", d.getQuestion())
        d.setAns(hiragana: "いえ", kanji: "家")
    }
    
    func testScoreCal(){
        // Test Setup
        let d = Dictation()
        d.setQuestionBank(chapter: "1")
        let totalNum = 16   // Totally 16 vocabs in "1.txt"
        XCTAssertEqual(totalNum, d.getSize())
        
        // Answer some question
        let scorePerQuestion = 100/totalNum
        d.setAns(hiragana: "いえ", kanji: "家"); d.next()
        XCTAssertEqual(String(scorePerQuestion), d.calScore())
        
        d.setAns(hiragana: "みせ", kanji: "店"); d.next()
        XCTAssertEqual(String(2*scorePerQuestion), d.calScore())
        
        d.setAns(hiragana: "みち", kanji: "道"); d.next()
        XCTAssertEqual(String(3*scorePerQuestion), d.calScore())
    }
    
    
    func testCorrection(){
        // Test Setup, answer some questions of the dictation
        let d = Dictation()
        d.setQuestionBank(chapter: "1")
        d.setAns(hiragana: "いえ", kanji: "家"); d.next()
        d.setAns(hiragana: "みせ", kanji: "店"); d.next()
        d.setAns(hiragana: "みち", kanji: "道"); d.next()
        
        // Get correction list
        let c = d.genCorrection()
        XCTAssertEqual(d.getSize()-3, c.getSize())  // Test for correct size
        XCTAssertEqual("Station", d.getQuestion())
    }
 
}
