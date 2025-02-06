//React Imports
import { useState } from "react";

import Navbar from "./Components/Navbar";
import Picker from "./Components/Picker";
import WheelControl from "./Components/WheelControl";
import WheelPicker from "./Components/WheelPicker";

function App() {
  const [startWheel, setStartWheel] = useState<boolean>(false);

  function handleStartWheel() {
    setStartWheel(true);

    setTimeout(() => {
      setStartWheel(false);
    }, 3000);
  }

  return (
    <>
      <Navbar />
      <Picker />
      <WheelPicker startWheel={startWheel} key={startWheel.toString()} />
      <WheelControl
        startWheel={startWheel}
        handleStartWheel={handleStartWheel}
      />
    </>
  );
}

export default App;
