function WheelPicker() {
  const alphabet: string[] = [
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

  const totalSlices: number = alphabet.length;
  const sliceAngle: number = 360 / totalSlices;
  const radius: number = 250; // Circle size

  return (
    <>
      <div
        className="flex items-center justify-center"
        style={{ height: "calc(100dvh - 56px)" }}
      >
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
                  begin="0s" //Countdown to start
                  dur="2s" //Force to run one loop of the wheel
                  // end="6s" //Duration
                  keyTimes="0; 0.6; 0.8; 0.9; 1"
                  values="0 0 0; 720 0 0; 900 0 0; 1050 0 0; 1327 0 0"
                  type="rotate"
                  // from="0 0 0"
                  // to="180 0 0"
                  // repeatCount="3"
                  fill="freeze"
                />
                {/* Slice */}
                <path
                  d={`M0 0 L${x1} ${y1} A${radius} ${radius} 0 0 1 ${x2} ${y2} Z`}
                  fill={`hsl(${(i * 360) / totalSlices}, 80%, 60%)`}
                  stroke="white"
                  strokeWidth="0.5"
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
