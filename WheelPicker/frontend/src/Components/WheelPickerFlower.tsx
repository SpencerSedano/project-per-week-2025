function WheelPicker() {
  const alphabet = [
    "A",
    "B",
    "C",
    "D",
    "E",
    "F",
    "G",
    "H",
    "I",
    "G",
    "K",
    "L",
    "M",
    "N",
    "O",
    "P",
    "Q",
    "R",
    "S",
    "T",
    "U",
    "V",
    "W",
    "X",
    "Y",
    "Z",
  ];
  const totalSlices = alphabet.length;
  const sliceAngle = 360 / totalSlices;
  const radius = 250; // Circle size

  return (
    <>
      <div className="flex h-screen items-center justify-center">
        <svg width="600" height="600" viewBox="-300 -300 600 600">
          {alphabet.map((label, i) => {
            const startAngle = (i * sliceAngle * Math.PI) / 180;
            const endAngle = ((i + 1) * sliceAngle * Math.PI) / 180;

            // Convert polar to cartesian
            // cos and sin expect radians, that is why
            // in the above code was converted
            const x1 = radius * Math.cos(startAngle);
            const y1 = radius * Math.sin(startAngle);
            const x2 = radius * Math.cos(endAngle);
            const y2 = radius * Math.sin(endAngle);

            // Text placement
            const textRadius = radius * 0.9;
            const textAngle = ((i + 0.5) * sliceAngle * Math.PI) / 180;
            const textX = textRadius * Math.cos(textAngle);
            const textY = textRadius * Math.sin(textAngle);

            return (
              <g key={i}>
                <animateTransform
                  attributeName="transform"
                  begin="0s"
                  dur="20s"
                  type="rotate"
                  from="0 0 0"
                  to="360 0 0"
                  repeatCount="indefinite"
                />
                {/* Slice */}
                <path
                  d={`M0 0 L${x1} ${y1} A${20} ${20} 0 0 1 ${x2} ${y2} Z`}
                  fill={`hsl(${(i * 360) / totalSlices}, 80%, 60%)`}
                  stroke="white"
                  strokeWidth="2"
                />

                {/* Label */}
                <text
                  x={textX}
                  y={textY}
                  fill="white"
                  fontSize="24"
                  textAnchor="middle"
                  dominantBaseline="middle"
                >
                  {label}
                </text>
              </g>
            );
          })}
        </svg>
      </div>
    </>
  );
}

export default WheelPicker;
