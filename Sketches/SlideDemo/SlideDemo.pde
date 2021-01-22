float x1, x2, x3;

float v2 = 0;

void setup(){
  size(500, 500);
}

void draw(){
  background(128);
  
  // simple, linear slide
  if(x1 < mouseX) x1 += 5;
  else if(x1 > mouseX) x1 -= 5;
  
  // euler physics based slide
  if(x2 < mouseX) v2 ++;
  if(x2 > mouseX) v2 --;
  x2 += v2;
  
  // damping: exponential slide (best) asymototic easing
  //x3 += (mouseX - x3) * .05; // Moves a percent of the distance between x3 and MouseX 
  x3 = lerp(x3, mouseX, .05); // Does the exact same thing as above equation.
  
  // Use the variables to draw ellipse
  ellipse(x1, 100, 30, 30);
  ellipse(x2, 200, 30, 30);
  ellipse(x3, 300, 30, 30);
}
