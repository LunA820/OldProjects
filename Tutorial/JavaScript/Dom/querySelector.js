const firstDiv = document.querySelector('div');
const firstP = document.querySelector('p');
const firstClass = document.querySelector('.gundam');

const all= document.querySelectorAll('p');

const divWithClass = document.querySelector('div.gundam');

console.log("Log first div by using querySelector")
console.log(firstDiv);
console.log("Log first <p> by using querySelector")
console.log(firstP);
console.log("Log first class by using querySelector")
console.log(firstClass);

console.log("Log all p tag method 1:")
console.log(all);
console.log("Log all p tag method 2:")
all.forEach(x => console.log(x));

console.log("Log Div with class")
console.log(divWithClass);