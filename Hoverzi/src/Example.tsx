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

  // Function to handle hover over the text container
  const handleTextHover = (event: React.MouseEvent<HTMLParagraphElement>) => {
    const x = event.clientX;
    const y = event.clientY;

    // Get the word under the cursor
    const range = document.caretRangeFromPoint?.(x, y);
    if (range) {
      // Adjust the range to include the full word
      adjustRangeToWord(range);

      const word = range.toString().trim();

      // Check if the word is in the dictionary
      if (dictionary[word.toLowerCase()]) {
        const selection = window.getSelection();
        selection?.removeAllRanges();
        selection?.addRange(range.cloneRange()); // Select the word
        setHoveredWord(word); // Track the hovered word
      }
    }
  };

  // Function to adjust the range to include the full word
  const adjustRangeToWord = (range: Range) => {
    // Move the start of the range to the beginning of the word
    while (
      range.startOffset > 0 &&
      !/\s/.test(range.startContainer.textContent![range.startOffset - 1])
    ) {
      range.setStart(range.startContainer, range.startOffset - 1);
    }

    // Move the end of the range to the end of the word
    while (
      range.endOffset < range.endContainer.textContent!.length &&
      !/\s/.test(range.endContainer.textContent![range.endOffset])
    ) {
      range.setEnd(range.endContainer, range.endOffset + 1);
    }
  };

  // Function to clear the selection when mouse leaves the text container
  const handleTextLeave = () => {
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
      <p
        onMouseMove={handleTextHover}
        onMouseLeave={handleTextLeave}
        style={{
          cursor: "pointer",
          userSelect: "none", // Prevent accidental text selection
        }}
      >
        {text}
      </p>
      <p>
        <strong>Dictionary Words:</strong> {Object.keys(dictionary).join(", ")}
      </p>
      {hoveredWord && (
        <p>
          <strong>Hovered Word:</strong> {hoveredWord}
        </p>
      )}
    </div>
  );
};

export default SelectOnHover;
