import React from 'react'


function PropsLab(props) {
  const numbers = [1, 2, 3, 4, 5];
  const listItems = numbers.map((n) => <li>{n}</li>);

  return (
    <div>
      <hr />
      <p><b>Props Lab</b></p>
      <p>
        This value is passed by props: {props.name}
        <br />
        
        This list is created by map function: {listItems}
      </p>
        
    </div>
  )
}

export default PropsLab;