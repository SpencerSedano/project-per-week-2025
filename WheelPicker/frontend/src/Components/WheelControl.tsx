function WheelControl({
  startWheel,
  handleStartWheel,
}: {
  startWheel: boolean;
  handleStartWheel: () => void;
}) {
  return (
    <>
      <div className="flex w-full justify-center bg-black text-white">
        <button
          className="h-24 w-24 cursor-pointer bg-amber-300"
          onClick={handleStartWheel}
        >
          Start: {`${startWheel}`}
        </button>
      </div>
    </>
  );
}

export default WheelControl;
