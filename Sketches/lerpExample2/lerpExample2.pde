//Creating our own LERP function!

void setup(){
  size(500, 500);
}

void draw(){
  background(128);
  
  float p = mouseX / (float) width;
  float size = lerpy(50, 300, p);
  
  fill(p * 255);
  ellipse(width/2, height/2, size, size);
  
}

//range = max - min
// range * percent is distance from min
// distance from min + min is the lerp function.

float lerpy(float min, float max, float p){
  float range = max - min;
  float offset = range * p;
  
  return min + offset;
}
