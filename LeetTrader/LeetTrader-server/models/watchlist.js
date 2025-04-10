const mongoose = require('mongoose')
const Schema = mongoose.Schema;


// Create Schema
const watchListSchema = new Schema({
  uid: {
    type: Number,
    required: true
  },
  sid: {
    type: String,
    required: true
  }
}, {timestamps: true});


// Create a model based on schema with a name "Watchlist"
const Watchlist = mongoose.model('Watchlist', watchListSchema)
module.exports = Watchlist;