//
//  JPDictTests.swift
//  JPDictTests
//
//  Created by LunA on 4/9/20.
//  Copyright © 2020 LunA Yang. All rights reserved.
//

import XCTest
@testable import JPDict

class VocabTests: XCTestCase {
    func testVocab(){
        let v = Vocab(eng: "Shop", hira: "みせ", kan: "店")
        XCTAssert("Shop" == v.getEng())
        XCTAssert("みせ" == v.getHira())
        XCTAssert("店" == v.getKan())
    }
    
    func testCreateQuestion(){
        // Setup Test
        let q = Question(eng: "Shop", hira: "みせ", kanji: "店")
        XCTAssertEqual("Shop", q.getQuestion())
        XCTAssertEqual(0, q.mark())
        XCTAssertEqual("みせ", q.getHira())
        XCTAssertEqual("店", q.getKanji())
    }
    
    func testMarkQuestion(){
        // Setup Test
        let q = Question(eng: "Home", hira: "いえ", kanji: "家")
        XCTAssertEqual("Home", q.getQuestion())
        XCTAssertEqual(0, q.mark())
        
        // Try wrong ans, 0 mark
        q.setAns(hira: "せ", kanji: "味")
        XCTAssertEqual(0, q.mark())

        // Try correct ans, 1 mark
        q.setAns(hira: "いえ", kanji: "家")
        XCTAssertEqual(1, q.mark())
    }
}
