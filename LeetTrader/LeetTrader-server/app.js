const express = require('express')
const cors = require('cors')
const mongoose = require('mongoose')
const dotenv = require('dotenv');


/*
  For demonstration purpose, two type of database are used:
   - MySQL (user, stocklist)
   - MongoDB (watchlist)
*/


// Configure Env
dotenv.config({ path: './.env'});

// Configure Express
const app = express();
app.use(express.json());
app.use(cors());
const port = 5000;

// Connect to MongoDB
const dbUrl = process.env.MONGODB
mongoose.connect(dbUrl, {useNewUrlParser: true, useUnifiedTopology: true})
.then((result)=>{
  console.log("Connected to MongoDB")
  app.listen(process.env.PORT || port, ()=>console.log(`Listening at ${port}`))
})
.catch(err => console.log(err))

// Define Routes
app.use('/auth', require('./routes/auth'))
app.use('/api', require('./routes/api'))  // Use MySql to handle data
app.use('/watchlist', require('./routes/watchlist'))  // Use MongoDB to handle data
app.get("/", (req, res)=>{res.send("LeetTrader")})
