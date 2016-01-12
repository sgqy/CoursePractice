


using System;
using System.Collections.Generic;

namespace Elevator
{
    class Elevator
    {
        const int infinity = 999999;

        // if T stop for movetime;
        // if F stop for parktime;
        List<bool> goUp; // 1, 2, 3, ..., n-2, n-1, n
        List<bool> goDn; // 1, 2, 3, ..., n-2, n-1, n (iter: inverse)

        int _xHi = 0, _xLo = 0; // Two limits of Up or Down
        void _updateHiLo()
        {
            if (goUp.Count != goDn.Count) throw new Exception("Runtime Error."); // How could this happen?
            _xLo = _curFloor;
            for (int i = 0; i < goUp.Count; ++i)
            {
                if (goUp[i] || goDn[i])
                {
                    _xLo = i;
                    break;
                }
            }
            _xHi = _curFloor;
            for (int i = goUp.Count - 1; i >= 0; --i)
            {
                if (goUp[i] || goDn[i])
                {
                    _xHi = i;
                    break;
                }
            }
        }

        int _movetime;
        int _parktime;

        public Elevator(int floors, int moveTime = 1, int parkTime = 3)
        {
            goUp = new List<bool>(floors);
            goDn = new List<bool>(floors);

            for (int i = 0; i < floors; ++i)
            {
                goUp.Add(false);
                goDn.Add(false);
            }
            _movetime = moveTime;
            _parktime = parkTime;

            _updateHiLo();
        }

        public bool IsError { get; set; }
        int _curFloor = 0;
        enum Direct
        {
            UpStairs,
            DnStairs,
            Ready,
        }
        Direct _curDirect;

        public int GetTime(int source)
        {
            if (IsError) return infinity;

            int ret = 0;
            if (_curDirect == Direct.Ready)
            {
                for (int i = _curFloor; i < source; ++i)
                    ret += goUp[i] ? _parktime : _movetime;
                for (int i = source; i < _curFloor; ++i)
                    ret += goDn[i] ? _parktime : _movetime;
            }
            else if (_curDirect == Direct.UpStairs)
            {
                if (_curFloor < source) // Go ahead
                {
                    // curFloor -Up-> source
                    for (int i = _curFloor; i < source; ++i)
                        ret += goUp[i] ? _parktime : _movetime;
                }
                else // One another round
                {
                    // curFloor -Up-> xHi -Dn-> xLo -Up-> source
                    for (int i = _curFloor; i < _xHi; ++i)
                        ret += goUp[i] ? _parktime : _movetime;
                    for (int i = _xHi - 1; i >= _xLo; --i)
                        ret += goDn[i] ? _parktime : _movetime;
                    for (int i = _xLo; i < source; ++i)
                        ret += goUp[i] ? _parktime : _movetime;
                }
            }
            else // _curDirect == Direct.DnStairs
            {
                if (_curFloor > source) // Go ahead
                {  // curFloor -Dn-> source
                    for (int i = _curFloor; i > source; --i)
                        ret += goDn[i] ? _parktime : _movetime;
                }
                else // One another round
                {
                    // curFloor -Dn-> xLo -Up-> xHi -Dn-> source
                    for (int i = _curFloor; i > _xLo; --i)
                        ret += goDn[i] ? _parktime : _movetime;
                    for (int i = _xLo; i < _xHi; ++i)
                        ret += goUp[i] ? _parktime : _movetime;
                    for (int i = _xHi; i > source; --i)
                        ret += goDn[i] ? _parktime : _movetime;
                }
            }
            return ret;
        }
        public int GetCurFloor() { return _curFloor; }

        int _remainTime = 0;
        public void Update()
        {
            if (_curDirect == Direct.Ready)
            {
                foreach (var s in goUp)
                    if (s)
                    {
                        _curDirect = Direct.UpStairs;
                        break;
                    }
                foreach (var s in goDn)
                    if (s)
                    {
                        _curDirect = Direct.DnStairs;
                        break;
                    }
            }
            else if (_curDirect == Direct.UpStairs)
            {
                if (goUp[_curFloor]) { if (_remainTime == 0) _remainTime = _parktime; }
                else { if (_remainTime == 0) _remainTime = _movetime; }

                if (--_remainTime == 0) // Timer
                {
                    bool isDelayed = false;
                    foreach (var s in _delayedUpTarget) // Search if delayed exists
                    {
                        if (s == _curFloor)
                        {
                            isDelayed = true;
                            goUp[_curFloor] = true; // Set forcely. Here has not a loop or recursion
                            _delayedUpTarget.Remove(s);
                            break;
                        }
                    }
                    if (!isDelayed) goUp[_curFloor] = false; // if exist, jump over

                    if (_curFloor < _xHi) ++_curFloor; // Do not use '!=' or loop infinity
                    else
                    {
                        _curDirect = Direct.DnStairs;
                        if (_xHi == _xLo) _curDirect = Direct.Ready;
                    }
                }
            }
            else // _curDirect == Direct.DnStairs
            {
                if (goDn[_curFloor]) { if (_remainTime == 0) _remainTime = _parktime; }
                else { if (_remainTime == 0) _remainTime = _movetime; }

                if (--_remainTime == 0)
                {
                    bool isDelayed = false;
                    foreach (var s in _delayedDnTarget)
                    {
                        if (s == _curFloor)
                        {
                            isDelayed = true;
                            goDn[_curFloor] = true;
                            _delayedDnTarget.Remove(s);
                            break;
                        }
                    }
                    if (!isDelayed) goDn[_curFloor] = false;

                    if (_curFloor > _xLo) --_curFloor;
                    else
                    {
                        _curDirect = Direct.UpStairs;
                        if (_xHi == _xLo) _curDirect = Direct.Ready;
                    }
                }
            }
            _updateHiLo();
        }

        HashSet<int> _delayedUpTarget = new HashSet<int>();
        HashSet<int> _delayedDnTarget = new HashSet<int>();
        public void SetWish(int source, int target)
        {
            if (source < target) // Want to go UpStairs
            {
                if (_curFloor <= source || _curFloor > target)
                    goUp[source] = goUp[target] = true;
                else
                {
                    goUp[source] = true;
                    _delayedUpTarget.Add(target);
                }
            }
            else if (source > target) // Want to go DownStairs
            {
                if (_curFloor >= source || _curFloor < target)
                    goDn[source] = goDn[target] = true;
                else
                {
                    goDn[source] = true;
                    _delayedDnTarget.Add(target);
                }
            }
            else // Assert: This case should thown by UI
            {
                throw new Exception("Internal Error.");
            }
            _updateHiLo();
        }
        public override string ToString() { return "Hi:" + _xHi + " Lo:" + _xLo + " Cur:" + _curFloor; }
    }

    class Controller
    {
        const int infinity = 999999;

        List<Elevator> _eles = new List<Elevator>();
        public void Add(Elevator e) { _eles.Add(e); }
        public void Update() { foreach (var s in _eles) { s.Update(); } }
        public List<int> GetStatus()
        {
            var ret = new List<int>();
            foreach (var s in _eles)
                ret.Add(s.GetCurFloor());
            return ret;
        }
        int _getIndex(int source)
        {
            var timeList = new List<int>();
            foreach (var s in _eles)
                timeList.Add(s.GetTime(source));

            int ret = 0;
            int min = infinity;
            for (int i = 0; i < timeList.Count; ++i)
            {
                if (timeList[i] < min)
                {
                    ret = i;
                    min = timeList[i];
                }
            }
            return ret;
        }
        public void SetWish(int source, int target) { _eles[_getIndex(source)].SetWish(source, target); }
        public void SetError(int index) { _eles[index].IsError = _eles[index].IsError ? false : true; }
        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < _eles.Count; ++i) { ret += i + "/" + _eles[i].ToString() + "\n"; }
            return ret;
        }
    }
}
