//Creating our own LERP function!

void setup() {
  size(500, 500);
}

void draw() {
  background(128);

  
  float size = mappy(mouseX, 0, width, 50, 300);
    
  
  ellipse(width/2, height/2, size, size);
}

float mappy(float inVal, float inMin, float inMax, float outMin, float outMax){
 // find p
 float p = (inVal - inMin) / (inMax - inMin);
  
 // lerp with p
 return lerpy(outMin, outMax, p);
 
}

//lerp functions with overloading.

float lerpy(float min, float max, float p){
  
  return lerpy(min, max, p, true);
}

// range = max - min
// range * percent is distance from min
// distance from min + min is the lerp function.

float lerpy(float min, float max, float p, boolean allowExtrapolation) {

  if (allowExtrapolation == false) {

    // Clamping values to get rid of extrapolation
    if (p < 0) p = 0;
    if (p > 1) p = 1;
  }

  float range = max - min;
  float offset = range * p;

  return min + offset;
}
