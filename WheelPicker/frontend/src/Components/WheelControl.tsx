function WheelControl({
  startWheel,
  handleStartWheel,
  loopDuration,
  handleLoopDuration,
}: {
  startWheel: boolean;
  handleStartWheel: () => void;
  loopDuration: string;
  handleLoopDuration: (e: React.ChangeEvent<HTMLInputElement>) => void;
}) {
  console.log(loopDuration);

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
      <input type="text" value={loopDuration} onChange={handleLoopDuration} />
      <p>{loopDuration}</p>
    </>
  );
}

export default WheelControl;
