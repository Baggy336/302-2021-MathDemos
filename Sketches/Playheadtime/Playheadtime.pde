// Declare variables for start and end of animation.
float valEnd = 500;
float valStart = 0;

// Variables for how long the animation will play.
float animLength = 5;
float animPlayheadTime = 0;
boolean isTweenPlaying= false; // Is the animation playing

float previousTimestamp = 0;

void setup() {
  size(500, 500);
}
void draw() {
  background(128);
  
  float currentTimestamp = millis() / 1000.0;
  float dt = currentTimestamp - previousTimestamp;
  previousTimestamp = currentTimestamp; // Set previous time stamp to current time stamp every frame.

  // Move playhead forward by deltatime
  if(isTweenPlaying){
    animPlayheadTime += dt;
    // Stop playing at end of tween
    if(animPlayheadTime > animLength){
      isTweenPlaying = false;
      animPlayheadTime = animLength;
    }
  }
  
  // Percent:
  float p = animPlayheadTime / animLength;
  
  // Manipulate p
  //p = p * p; // Bends curve down.
  //p = 1 - p; // Plays animation backwards.
  //p = 1 - (1 - p) * (1 - p); // Slows the object towards the end of anim.
  p = p * p * (3 - 2 * p); // Ease in and ease out.
  
  float x = lerp(valStart, valEnd, p);

  ellipse(x, height/2.0, 20, 20);
} 
void mousePressed(){
  animPlayheadTime = 0; // Restarts animation on mouse click
  isTweenPlaying = true;
}
