﻿using clothing_store.Common.Rsp;
using clothing_store.Common.BLL;

namespace clothing_store.BLL
{
    using clothing_store.Common.Req;
    using clothing_store.DAL.Models;
    using DAL;

    public class CartsSvc : GenericSvc<CartsRep, Carts>
    {
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override int Remove(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Remove(id);
            res.Data = m;

            return 0;
        }

        public override SingleRsp Update(Carts m)
        {
            var res = new SingleRsp();

            var m1 = m.CartId > 0 ? _rep.Read(m.CartId) : _rep.Read(m.CartId);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion

        #region -- Methods --
        public SingleRsp CreateCart(CartsReq cart)
        {
            var res = new SingleRsp();
            Carts carts = new Carts();
            carts.CartId = cart.CartId;
            carts.Size = cart.Size;
            carts.UnitPrice = cart.UnitPrice;
            carts.Quantity = cart.Quantity;
            carts.ProductId = cart.ProductId;
            carts.UserId = cart.UserId;

            res = _rep.CreateCart(carts);
            return res;
        }

        public SingleRsp UpdateCart(int UserId, string Size, short Quantity)
        {
            var res = new SingleRsp();
            res = _rep.UpdateCart(UserId, Size, Quantity);
            return res;
        }

        public SingleRsp DeleteCart(int UserId)
        {
            var res = new SingleRsp();
            res = _rep.DeleteCart(UserId);
            return res;
        }

        public object FindCart(int UserId)
        {
            return _rep.FindCart(UserId);
        }
    }
}
