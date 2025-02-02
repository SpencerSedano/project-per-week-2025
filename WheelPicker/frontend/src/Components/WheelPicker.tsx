// import SvgWheel from "../assets/svg/wheel.svg";

function WheelPicker() {
  return (
    <>
      {/* <img src={SvgWheel} alt="Wheel Picker" /> */}
      <div className="flex items-center justify-center">
        <div className="relative h-36 w-36 overflow-hidden rounded-full bg-amber-300">
          <span className="absolute bottom-1/2 left-1/2 inline h-full w-full origin-bottom-left transform align-middle">
            A
          </span>
          <span className="absolute bottom-1/2 left-1/2 inline h-full w-full origin-bottom-left transform align-middle">
            B
          </span>
          <span className="absolute bottom-1/2 left-1/2 inline h-full w-full origin-bottom-left transform align-middle">
            C
          </span>
          <span className="absolute bottom-1/2 left-1/2 inline h-full w-full origin-bottom-left transform align-middle">
            D
          </span>
          <span className="absolute bottom-1/2 left-1/2 inline h-full w-full origin-bottom-left transform align-middle">
            E
          </span>
        </div>
      </div>
    </>
  );
}

export default WheelPicker;
