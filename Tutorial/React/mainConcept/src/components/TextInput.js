import React from 'react'


class TextInput extends React.Component{
    constructor(props) {
      super(props);
      this.state = {value: ''};
  
      this.handleChange = this.handleChange.bind(this);
      this.handleSubmit = this.handleSubmit.bind(this);
    }
    
    handleChange(event) {
      this.setState({value: event.target.value});
    }
  
    handleSubmit(event) {
      alert('A name was submitted: ' + this.state.value);
      event.preventDefault();
    }
  
    render() {
      return (
          <div>
              <hr />
              <p><b>Text Input Lab</b></p>
              <form onSubmit={this.handleSubmit}>
                  <label>
                      Text: 
                      <input type="text" value={this.state.value} onChange={this.handleChange} />
                  </label>

                  <input type="submit" value="Submit" />
              </form>

              <p>Copy: {this.state.value}</p>

              <hr />
          </div>
      );
    }

}

export default TextInput;