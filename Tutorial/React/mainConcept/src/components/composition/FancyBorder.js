import React from "react";

// props.children is a keyword
function FancyBorder(props) {
    return (
      <div className={'FancyBorder FancyBorder-' + props.color}>
        {props.children}
      </div>
    );
}

export default FancyBorder;