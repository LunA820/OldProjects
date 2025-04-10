import React from 'react'


class StateLab extends React.Component{
    constructor(props){
        super(props);
        this.state = { toggleOn: true };

        this.click = this.click.bind(this);
    }

    click(){
        this.setState(prev => ({
            toggleOn: !prev.toggleOn
        }));
    }

    render(){
        return (
            <div>
                <hr />
                <p><b>State Lab</b></p>
                This button can remember its previous state:
                <button onClick={this.click}>
                    {this.state.toggleOn ? 'ON' : 'OFF'}
                </button>
            </div>
        )
    }
}


export default StateLab;