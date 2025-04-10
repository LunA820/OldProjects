const request = require('request')

class apiManager{
  constructor(){
    this.url = 'https://finnhub.io/api/v1/quote?symbol='
    this.token = '&token=bth7d9f48v6v983bgc70'
  }

  search(sid){
    return new Promise((resolve, rej)=>{
      request(
        this.url+sid+this.token,
        { json: true },
        (err, res, body) => {
          if (err) { return resolve(-1);}
          resolve(body);
      });
    })
  }

  getCurrPrice(sid){
    return new Promise((resolve, rej)=>{
      this.search(sid).then(data => {
        if (data === -1){return resolve(-1)}
        resolve(data.c)
      })
    })
  }

  getDiff(sid){
    return new Promise((resolve, rej)=>{
      this.search(sid).then(data=>{
        if (data === -1){return resolve(-1)}
        resolve(data.c - data.pc)
      })
    })
  }

};


module.exports = {apiManager}