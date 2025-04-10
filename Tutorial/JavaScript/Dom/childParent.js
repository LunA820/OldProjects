const article = document.querySelector('article');
children = article.children;
console.log(children);  // Return an HTMLCollection


/**
 * We cannot use foreach on HTML Collection.
 * In order to cycle through the elements in the HTMLCollection, 
 * we need to convert it into an array first
 */
const a = Array.from(children)
console.log(a);

/**
 * Now we can loop through the array of children.
 * We can do something like adding a css class to each children.
 */
a.forEach(x => {
    x.classList.add('myClasss');    // Inspect in LiveServer, the className = 'myClass' now
    x.innerText = 'from javascript';
    x.style.color = 'blue';
})


// Similarly, we can find the parent of an element
const title = document.querySelector('h2');
const p = title.parentElement;
console.log(p); // Check console to see the parent element being logged