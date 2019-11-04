#if !defined(__VECTOR_H__)
#define __VECTOR_H__

class Vector {
	int x, y;
public:
	Vector(int _x, int _y) {x = _x; y = _y;};
	Vector() {x = 0; y = 0;};
	Vector operator +(Vector _v) {
		Vector r(x, y);
		r.x += _v.x;
		r.y += _v.y;
		return r;
	};
	Vector operator -(Vector _v) {
		Vector r(x, y);
		r.x -= _v.x;
		r.y -= _v.y;
		return r;
	};
	Vector operator =(Vector _v) {
		this->x = _v.x;
		this->y = _v.y;
		return *this;
	};
	int operator ==(Vector _v) {return (x == _v.x) && (y == _v.y);};
	int operator !=(Vector _v) {return (x != _v.x) || (y != _v.y);};
	int operator <(Vector _v) {return (x < _v.x) && (y < _v.y);};
	int operator >(Vector _v) {return (x > _v.x) && (y > _v.y);};
	int operator <=(Vector _v) {return (x <= _v.x) && (y <= _v.y);};
	int operator >=(Vector _v) {return (x >= _v.x) && (y >= _v.y);};
	int getX() {return x;};
	int getY() {return y;};
	Vector setX(int _x) {x = _x;	return *this;};
	Vector setY(int _y) {y = _y;	return *this;};
	Vector zoom(Vector _v) {return Vector(x * _v.x, y * _v.y);};
	Vector mooz(Vector _v) {return Vector(x / _v.x, y / _v.y);};
};
#endif	// __VECTOR_H__
