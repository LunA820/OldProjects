
/**
 * If we use setAttribute to change the style,
 * we will completely overwrite the original style of the DOM object.
 */
var title = document.querySelector('h1');
title.setAttribute('style', 'margin: 50px');


// Modify the style attribute such that the style won't be totally overwritten
var title2 = document.querySelector('h2');
title2.style.margin = '50px';
title2.style.fontSize = '100px';




