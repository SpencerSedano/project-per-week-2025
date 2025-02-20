function WheelPicker({ startWheel }: { startWheel: boolean }) {
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

  const minRandNumber: number = 500;
  const maxRandNumber: number = 1500;

  const randomKeyFrames: number[] = [
    //   Math.random() * (maxRandNumber - minRandNumber) + minRandNumber,
    //   Math.random() * (maxRandNumber - minRandNumber) + minRandNumber,
    //   Math.random() * (maxRandNumber - minRandNumber) + minRandNumber,
    //   Math.random() * (maxRandNumber - minRandNumber) + minRandNumber,
  ];

  for (let index = 0; index < 4; index++) {
    randomKeyFrames[index] = Math.floor(
      Math.random() * (maxRandNumber - minRandNumber) + minRandNumber,
    );
  }
  const sortedRandomKeyFrames = randomKeyFrames.sort(function (a, b) {
    return a - b;
  });
  sortedRandomKeyFrames.forEach((element) => console.log(element));

  return (
    <>
      <div
        className="flex items-center justify-center"
        style={{ height: "calc(100dvh - 132px)" }}
      >
        <svg width="600" height="600" viewBox="-300 -300 600 600">
          {alphabet.map((label, i) => {
            //Angles in degress
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
                {startWheel && (
                  <animateTransform
                    attributeName="transform"
                    begin="0s" //Countdown to start, will be a variable
                    dur="5s" //Force to run one loop of the wheel
                    // end="6s" //Duration
                    keyTimes="0; 0.5; 0.7; 0.9; 1"
                    values={`0 0 0; ${sortedRandomKeyFrames[0]} 0 0; ${sortedRandomKeyFrames[1]} 0 0; ${sortedRandomKeyFrames[2]} 0 0; ${sortedRandomKeyFrames[3]} 0 0`}
                    type="rotate"
                    // from="0 0 0"
                    // to="180 0 0"
                    // repeatCount="3"
                    fill="freeze"
                  />
                )}
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
