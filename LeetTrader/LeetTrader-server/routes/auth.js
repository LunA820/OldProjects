const express = require('express');
const router = express.Router();
const dbManager = require('../manager/dbManager')

const db = new dbManager.dbManager();

// Register user, return -1 if fail
router.post("/register", (req, res)=>{
  db.register(req.body.email, req.body.password, res)
})

// Login, return user ID, return -1 if fail
router.post("/login", (req, res)=>{
  db.login(req.body.email, req.body.password, res)
})

// Reset user account
router.post("/reset", (req, res)=>{
  db.reset(req.body.uid, res)
})


module.exports = router;