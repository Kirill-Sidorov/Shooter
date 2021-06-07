
namespace View.Items
{
    public abstract class ViewObject
    {
        /// <summary>
        /// Смещение объекта по оси X
        /// </summary>
        protected int _offsetX;
        /// <summary>
        /// Смещение объекта по оси Y
        /// </summary>
        protected int _offsetY;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parOffsetX">Смещение объекта по оси Х</param>
        /// <param name="parOffsetY">Смещение объекта по оси Y</param>
        public ViewObject(int parOffsetX, int parOffsetY)
        {
            _offsetX = parOffsetX;
            _offsetY = parOffsetY;
        }

        public abstract void Draw();
    }
}
