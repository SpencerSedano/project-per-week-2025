import { useState } from "react";

function App() {
  interface MyDictionary {
    traditional: string;
    english: string;
  }

  const myChineseDictionary: MyDictionary[] = [
    { traditional: "我", english: "I" },
    { traditional: "現在", english: "right now" },
    { traditional: "在", english: "in" },
    { traditional: "看", english: "to look" },
    { traditional: "軟體", english: "software" },
    { traditional: "的", english: "possessive" },
    { traditional: "能力", english: "capable" },
  ];

  const [selectionWord, setSelectionWord] = useState<string>("");

  function handleMouseHover(
    word: string,
    event: React.MouseEvent<HTMLSpanElement>
  ) {
    if (myChineseDictionary[word.toLowerCase()]) {
      const range = document.createRange();
      range.selectNodeContents(event.currentTarget);
      const selection = window.getSelection();
      selection?.removeAllRanges();
      selection?.addRange(range);
      setSelectionWord(word);
    }
  }

  return (
    <>
      <div onMouseOver={handleMouseHover}>我現在在看軟體的能力</div>
      <ul>
        {myChineseDictionary.map((value, index) => (
          <li key={index}>
            {value.traditional} and {value.english}
          </li>
        ))}
      </ul>
      <p>Selected: {selectionWord || "None"}</p>
    </>
  );
}

export default App;
