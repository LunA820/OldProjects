const express = require('express')
const router = express.Router();
const Watchlist = require('../models/watchlist')
const apiManager = require('../manager/apiManager')

const api = new apiManager.apiManager();


// Add new entry to watchlist, return true if success
router.post('/add', (req, res)=>{
  
  // Find if entry already existed
  Watchlist.find({uid: req.body.uid, sid: req.body.sid})
  .then(result=>{
    // Return if already existed
    if (result.length > 0){return res.json(false)}

    // Add new watchlist entry
    const watchlist = new Watchlist({
      uid: req.body.uid,
      sid: req.body.sid
    });
    watchlist.save()
    .then(result2 => res.json(true))
    .catch(err => res.json(false))
  })
})


// Remove an entry from watchlist, return true if success
router.post('/remove', (req, res)=>{
  Watchlist.deleteOne({
    uid: req.body.uid,
    sid: req.body.sid
  })
  .then((result) => {
    if (result.deletedCount === 0){return res.json(false)}
    return res.json(true)
  })
  .catch(err => res.json(false))
})


// Get uesr's watchlist
router.get('/:uid', (req, res)=>{
  Watchlist.find({uid: parseInt(req.params.uid)})
  .then(async (data) => {
    let watchlist = []

    for (let i = 0; i < data.length; i++){
      let diff = await api.getDiff(data[i].sid)
      watchlist.push({sid: data[i].sid, diff: diff})
    }
    res.json(watchlist)
  })
  .catch((err) => res.json(false))
})


module.exports = router;