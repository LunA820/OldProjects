
const content = document.querySelector('h2');
const content2 = document.querySelector('h3');

console.log(content.classList); // check in console window
content.classList.remove('green'); 
content.classList.add('red');

content2.classList.remove('red');
content2.classList.add('green');


// The toggle method can add or remove a class depends on whether it has a class or not
content2.classList.toggle('green');
console.log(content2.classList); // check in console window
content2.classList.toggle('green');
console.log(content2.classList); // check in console window