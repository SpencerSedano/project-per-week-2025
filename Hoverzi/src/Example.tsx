import React, { useState } from "react";

// Example JSON dictionary
const dictionary: Record<string, boolean> = {
  text: true,
  select: true,
  hover: true,
  react: true,
  typescript: true,
};

const SelectOnHover: React.FC = () => {
  const [hoveredWord, setHoveredWord] = useState<string | null>(null);

  // Function to handle hover over a word
  const handleWordHover = (
    word: string,
    event: React.MouseEvent<HTMLSpanElement>
  ) => {
    if (dictionary[word.toLowerCase()]) {
      const range = document.createRange();
      range.selectNodeContents(event.currentTarget); // Select the word
      const selection = window.getSelection();
      selection?.removeAllRanges();
      selection?.addRange(range);
      setHoveredWord(word); // Track the hovered word
    }
  };

  // Function to clear the selection when mouse leaves a word
  const handleWordLeave = () => {
    const selection = window.getSelection();
    selection?.removeAllRanges();
    setHoveredWord(null); // Clear the hovered word
  };

  // Sample text to display
  const text =
    "This is a sample text to demonstrate word-by-word selection in React with TypeScript.";

  return (
    <div>
      <h1>Hover to Select Words</h1>
      <p>
        {text.split(" ").map((word, index) => (
          <span
            key={index}
            onMouseOver={(e) => handleWordHover(word, e)}
            onMouseLeave={handleWordLeave}
            style={{
              padding: "2px",
              backgroundColor: hoveredWord === word ? "yellow" : "transparent",
              cursor: "pointer",
            }}
          >
            {word}{" "}
          </span>
        ))}
      </p>
      <p>
        <strong>Dictionary Words:</strong> {Object.keys(dictionary).join(", ")}
      </p>
    </div>
  );
};

export default SelectOnHover;
