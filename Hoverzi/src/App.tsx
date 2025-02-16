import { useState } from "react";
import dict from "./cedict.json";

function App() {
  interface MyDictionary {
    traditional: string;
    english: string;
  }

  // const myChineseDictionary: MyDictionary[] = [
  //   { traditional: "我", english: "I" },
  //   { traditional: "現在", english: "right now" },
  //   { traditional: "在", english: "in" },
  //   { traditional: "看", english: "to look" },
  //   { traditional: "軟體", english: "software" },
  //   { traditional: "的", english: "possessive" },
  //   { traditional: "能力", english: "capable" },
  //   { traditional: "你", english: "you" },
  //   { traditional: "你好", english: "hello" },
  //   { traditional: "是", english: "is" },
  // ];

  const myChineseDictionary: MyDictionary[] = dict as MyDictionary[];

  const [selectedWords, setSelectedWords] = useState<string>("");
  const [hoveredText, setHoveredText] = useState<string>("");

  console.log("hoveredText:", hoveredText);
  console.log("Selected Words:", selectedWords);

  const handleMouseHover = (event: React.MouseEvent<HTMLSpanElement>) => {
    const hoveredWord = event.currentTarget.textContent?.trim() || "";
    if (!hoveredWord) return;

    // Append the hovered word to state
    // Helps to make compound words, in this case, 2 Chinese characters or more
    const newSelectedWords = selectedWords + hoveredWord;

    // Check if the accumulated selection matches a dictionary entry
    const dictionaryEntry = myChineseDictionary.find(
      (entry) => entry.traditional === newSelectedWords
    );

    // If there is a dictionaryEntry
    if (dictionaryEntry) {
      const selection = window.getSelection();
      const range = document.createRange();

      if (!selection?.rangeCount) {
        // Start new selection
        range.selectNode(event.currentTarget);
        selection?.removeAllRanges();
        selection?.addRange(range);
      } else {
        // Extend selection
        range.setStart(
          selection.getRangeAt(0).startContainer,
          textArray.indexOf(hoveredText)
        );
        range.setEndAfter(event.currentTarget);
        selection.removeAllRanges();
        selection.addRange(range);
      }

      setSelectedWords(newSelectedWords);
      setHoveredText(newSelectedWords);
      console.log(dictionaryEntry.english);
    }
  };

  // Function to clear the selection when mouse leaves
  const handleMouseLeave = () => {
    const selection = window.getSelection();
    selection?.removeAllRanges();
    setSelectedWords("");
    setHoveredText("");
  };

  // Example text split into words
  const text = "你好， 我是余青澔，我喜歡吃牛排。";
  const textArray = text.split("");
  console.log(textArray);

  return (
    <>
      <div className="w-32 bg-amber-300" onMouseLeave={handleMouseLeave}>
        {textArray.map((word, index) => (
          <span
            key={index}
            onMouseOver={handleMouseHover}
            style={{ cursor: "pointer", padding: "0 0px" }}
          >
            {word}
          </span>
        ))}
      </div>
      {/* <ul>
        {myChineseDictionary.map((value, index) => (
          <li key={index}>
            {value.traditional} - {value.english}
          </li>
        ))}
      </ul> */}
      <p>Selected: {selectedWords || "None"}</p>
      <p>Hovered Text: {hoveredText || "None"}</p>
    </>
  );
}

export default App;
