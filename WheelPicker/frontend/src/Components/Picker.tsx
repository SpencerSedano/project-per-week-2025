import PickerSvg from "../assets/svg/PickerSvg.svg";

function Picker() {
  return (
    <>
      <div className="absolute top-35 z-20 flex size-24 w-full justify-center">
        <img src={PickerSvg} alt="Picker" />
      </div>
    </>
  );
}

export default Picker;
