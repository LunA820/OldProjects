import FancyBorder from "./FancyBorder";

function WelcomeDialog() {
    return (
      <FancyBorder color="blue">
        <hr />
        
        <h4 className="Dialog-title">
          Props.children Lab
        </h4>

        <p className="Dialog-message">
          Thank you for visiting our spacecraft!
        </p>
      </FancyBorder>
    );
}

export default WelcomeDialog;