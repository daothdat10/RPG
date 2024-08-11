using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class InvenStorySlot 
{
   private Stack<IIventoryItem> mItemStack = new Stack<IIventoryItem>();

    private int mId = 0;

    public InvenStorySlot(int id)
    {

        mId = id;
    }

    public int Id
    {
        get { return mId; }

    }

    public void AddItem(InventoryItemBase item)
    {
        item.Slot = this;
      mItemStack.Push(item);  
    }

    public bool IsEmpty
    {
        get { return Count == 0; }
    }

    public int Count
    {
        get { return mItemStack.Count; }
    }

    public bool Remove(IIventoryItem item)
    {
        if(IsEmpty) return false;


        IIventoryItem first = mItemStack.Peek();
        if(first.Name == item.Name)
        {
            mItemStack.Pop();
            return true;
        }
        return false;
    }

    public bool IsStackable(IIventoryItem item)
    {
        if(IsEmpty) return false;

        IIventoryItem first = mItemStack.Peek();

        if(first.Name ==item.Name) return true;

        return false;
    }
    public InventoryItemBase FirstItem
    {
        get
        {
            if (IsEmpty)
                return null;

            return (InventoryItemBase)mItemStack.Peek();
        }
    }
}
