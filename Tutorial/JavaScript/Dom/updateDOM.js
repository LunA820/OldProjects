/**
 * This tutorial shows some basic methods to query and update the DOM objects,
 * such that you can change the website by using JavaScript.
 */

// QuerySelector & InnerText
const x = document.querySelector('p');
x.innerText = 'I used Javascript to change the innerText to this.';
const paraList = document.querySelectorAll('p');
paraList.forEach(x => x.innerText = 'Text comes from JavaScript');

// InnerHTML
const g = document.querySelector('.gundam');
console.log(g);
g.innerHTML = '<h3>Nu Gundam</h3>';

// GetElementById
const e = document.getElementById('patlabor');
e.innerText = 'Luna'

// Attributes
const a = document.querySelector('a');
console.log(a.getAttribute('href'));
a.setAttribute('href', 'https://www.google.com');
a.setAttribute('target', '_blank');
a.innerText = 'Link to Google';
