function BoilingVerdict(props) {
    return <p>The water would {props.celsius >= 100 ? "": "not"} boil.</p>
}

export default BoilingVerdict;