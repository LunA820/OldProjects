import './App.css';
import PropsLab from './components/PropsLab';
import StateLab from './components/StateLab';
import TextInput from './components/TextInput';
import Calculator from './components/liftingState/Calculator';
import WelcomeDialog from './components/composition/WelcomeDialog';


function App() {
  return (
    <div className="App">
      <PropsLab name="Luna"/>
      <StateLab />
      <TextInput />
      <Calculator />
      <WelcomeDialog />
    </div>
  );
}

export default App;
