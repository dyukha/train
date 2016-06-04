#ifndef _IPOINT_H_
#define _IPOINT_H_

template<typename T>
class IPoint {
public:
  virtual T X() = 0;
  virtual T Y() = 0;
  inline T SqrLen() { T x = X(); T y = Y(); return x * x + y * y; }

  template<typename T2>
  friend IPoint<T2>* operator+(const IPoint<T2>&, const IPoint<T2>&);

  template<typename T2>
  friend IPoint<T2>* operator-(const IPoint<T2>&, const IPoint<T2>&);

  static IPoint* Create(T x, T y);
};

#endif
