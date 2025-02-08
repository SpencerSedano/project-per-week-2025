//React Imports
import { useState } from "react";

import Navbar from "./Components/Navbar";
import Picker from "./Components/Picker";
import WheelControl from "./Components/WheelControl";
import WheelPicker from "./Components/WheelPicker";

function App() {
  const [startWheel, setStartWheel] = useState<boolean>(false);
  const [loopDuration, setLoopDuration] = useState<string | null>(null);

  function handleStartWheel() {
    setStartWheel(true);

    setTimeout(() => {
      setStartWheel(false);
    }, 10000);
  }

  function handleLoopDuration(e: React.ChangeEvent<HTMLInputElement>) {
    setLoopDuration(e.target.value);
  }

  return (
    <>
      <Navbar />
      <Picker />
      <WheelPicker startWheel={startWheel} key={startWheel.toString()} />
      <WheelControl
        startWheel={startWheel}
        handleStartWheel={handleStartWheel}
        loopDuration={loopDuration ?? ""}
        handleLoopDuration={handleLoopDuration}
      />
    </>
  );
}

export default App;
