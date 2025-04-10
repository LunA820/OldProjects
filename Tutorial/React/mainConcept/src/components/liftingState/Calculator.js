import React from 'react';
import BoilingVerdict from './BoilingVerdict';
import TemperatureInput from './TemperatureInput';

/**
 * Sometimes we wants components to share common data, 
 * one common method to achieve this is to lift each components' state (common data) one level up to their closest common ancenster.
 * 
 * In this example, we have a <Calculator /> which contains 2 React.Components <TemperatureInput />:
 *      - Both components are text input components
 *      - One component represent celsius & another represents fahrenheit
 *      - When user type in one component, another component need to display the value that represents the corresding temperature value
 * 
 * To summarize the concept, instead of letting one component to be the "source of truth",
 * we use a parent component to be the "source of truth", then translate the parent's state into children's states
 */
class Calculator extends React.Component {
    constructor(props) {
      super(props);

      // Functions that will be passed to <TemperatureInput /> as props
      this.handleCelsiusChange = this.handleCelsiusChange.bind(this);
      this.handleFahrenheitChange = this.handleFahrenheitChange.bind(this);

      // Common data of <TemperatureInput />
      this.state = {temperature: '', scale: 'c'};
    }
  

    // No matter which component's input is received, there will be a function to handle it
    handleCelsiusChange(temperature) {this.setState({scale: 'c', temperature});}
    handleFahrenheitChange(temperature) {this.setState({scale: 'f', temperature});}
  

    render() {
      const scale = this.state.scale;
      const temperature = this.state.temperature;

      // Translate Calculator state to TemperatureInput props (state)
      const celsius = (scale === 'f') ? tryConvert(temperature, toCelsius) : temperature;
      const fahrenheit = (scale === 'c') ? tryConvert(temperature, toFahrenheit) : temperature;
  
      return (
        <div>
          <p><b>Lifting State Lab</b></p>

          <TemperatureInput
            scale="c"
            temperature={celsius}
            onTemperatureChange={this.handleCelsiusChange} />

          <TemperatureInput
            scale="f"
            temperature={fahrenheit}
            onTemperatureChange={this.handleFahrenheitChange} />

          <BoilingVerdict celsius={parseFloat(celsius)} />
        </div>
      );
    }
}


// Helper Functions
const toCelsius = (f) => (f - 32) * 5 / 9;
const toFahrenheit = (c) => (c * 9 / 5) + 32;
function tryConvert(temperature, convert) { // Convert is a function
    const input = parseFloat(temperature);
    if (Number.isNaN(input)) { return '';}

    const output = convert(input);  // Convert is a function
    const rounded = Math.round(output * 1000) / 1000;
    return rounded.toString();
}


export default Calculator;