using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Olympus.LI.Triumph.Application.ViewModel {
    public class UiController {
        public static UiController sUiController = new UiController();

        public Acquisition Acquisition = new Acquisition();
        public DetailSetting DetailSetting = new DetailSetting();
        public Display Display = new Display();
        public Focus Focus = new Focus();
        public Layout Layout = new Layout();
        public Measurement Measurement = new Measurement();
        public Preview Preview = new Preview();
        public Stage Stage = new Stage();
    }

    public class Acquisition {
        public System.Windows.Controls.Label StitchingExtendStopActionLabel;
        public System.Windows.Controls.Label ExtendStopActionLabel;
        public int HorizontalSheets;
        public string HorizontalLength;
        public int VerticalSheets;
        public string VerticalLength;
        public object ConvertToIntFromEmOverlap(object value) {
            return value;
        }

        internal object ConvertToEmOverLapFromInt(int p) {
            throw new NotImplementedException();
        }

        internal void MapMouseMoveEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MapMouseDoubleClickEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MapMouseDownEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MapMouseUpEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MapMouseLeaveEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MapMouseEnterEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MapTouchDownEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MapTouchMoveEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MapTouchUpEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MapTouchLeaveEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MapTouchEnterEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal bool IsAreaDesignationTypeSheets() {
            throw new NotImplementedException();
        }
    }

    public class Layout {
        public String CommonUnit;
        public void ZPositionAreaMouseEnterHandler() {
        }
        public void ObservationLocationAreaMouseEnterHandler() {
        }
        public void ZoomAreaMouseEnterHandler() {
        }
        public bool IsExecWindowClosing() {
            return true;
        }

        internal void MouseLeftButtonDownEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }
    }

    public class Stage {
        public void AlignmentBAPListCellEditEndingHandler(Object e) {
        }

        public void StageCoordinatesListSelectionChangedHandler(IList list) {
        }

        public void RowCountTextChangedHandler(String s1, String s2) {
        }

        public void ColumnCountTextChangedHandler(String s1, String s2) {
        }

        public void RowPitchTextChangedHandler(string p) {
        }

        public void ColumnPitchTextChangedHandler(string p) {
        }

        internal void StageCommandSpeedChange() {
            throw new NotImplementedException();
        }

        internal void StageControllerDirectionMouseDownEventHandler(int _DIRECTION_LEFTUP) {
            throw new NotImplementedException();
        }

        internal void StageControllerDirectionMouseUpEventHandler() {
            throw new NotImplementedException();
        }

        internal void StageCommandSpeedChangeForLiveStitching() {
            throw new NotImplementedException();
        }

        internal void StageStitchingStepMoveMouseDownEventHandler(int _DIRECTION_UP) {
            throw new NotImplementedException();
        }

        internal void StageControllerDirectionMouseUpEventHandlerForLiveStitching() {
            throw new NotImplementedException();
        }

        internal void StageControllerDirectionMouseDownEventHandlerForLiveStitching(int _DIRECTION_LEFTUP) {
            throw new NotImplementedException();
        }
    }

    public class Display {
        internal void MouseMoveEventHandler(System.Windows.Point ptMousePosition) {
            throw new NotImplementedException();
        }

        internal void MouseDoubleClickEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MouseDownEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MouseUpEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void MouseWheelEventHandler(int p) {
            throw new NotImplementedException();
        }

        internal void MouseLeaveEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void ManipulationStartingHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void ManipulationDeltaHandler(double p, double p_2, System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void ManipulationInertiaStartingHandler(double p, double p_2, System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void StillImageMouseMoveEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void StillImageMouseLeaveEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void LiveStitchingMouseWheelEventHandler(int p) {
            throw new NotImplementedException();
        }

        internal void SetScrollViewerForGetOffsetForLiveCCDImage(ref System.Windows.Controls.ScrollViewer scrollViewer) {
            throw new NotImplementedException();
        }

        internal void SetScrollViewerForGetOffsetForStillImage(ref System.Windows.Controls.ScrollViewer scrollViewer) {
            throw new NotImplementedException();
        }

        internal void SetScrollViewerForGetOffsetForLive(ref System.Windows.Controls.ScrollViewer scrollViewer) {
            throw new NotImplementedException();
        }

        internal void LiveStitchingMouseMoveEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void LiveStitchingMouseDownEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void LiveStitchingMouseUpEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void LiveStitchingMouseLeaveEventHandler(System.Windows.Point point) {
            throw new NotImplementedException();
        }

        internal void SetScrollViewerForGetOffsetForStitchingImage(ref System.Windows.Controls.ScrollViewer scrollViewer) {
            throw new NotImplementedException();
        }

        public System.Windows.Visibility GridItemVisibility;
    }

    public class DetailSetting {
        internal void UnBindExpander(System.Windows.Controls.Expander expander) {
            throw new NotImplementedException();
        }
    }

    public class Measurement {
        internal void SetMeasurementsSettingVisibility(System.Windows.Visibility visibility) {
            throw new NotImplementedException();
        }
    }

    public class Focus {
        internal void MoveUpContinuouslyStart() {
            throw new NotImplementedException();
        }

        internal void MoveContinuouslyStop() {
            throw new NotImplementedException();
        }

        internal void MoveDownContinuouslyStart() {
            throw new NotImplementedException();
        }

        internal void ChangeZContinuousMovingSpeedTypeFromMouse() {
            throw new NotImplementedException();
        }

        internal void ChangeZContinuousMovingSpeedTypeFromTouch() {
            throw new NotImplementedException();
        }

        internal void RoughMoveStart() {
            throw new NotImplementedException();
        }

        internal void RoughMoveStop() {
            throw new NotImplementedException();
        }

        internal void DetailMoveStart() {
            throw new NotImplementedException();
        }

        internal void DetailMoveStop() {
            throw new NotImplementedException();
        }
    }

    public class Preview {
        internal void MouseMoveEventHandler(int id, bool p) {
            throw new NotImplementedException();
        }

        internal void MouseDownEventHandler(int id) {
            throw new NotImplementedException();
        }

        internal void MouseUpEventHandler(int id) {
            throw new NotImplementedException();
        }

        internal void MouseEnterEventHandler(int id) {
            throw new NotImplementedException();
        }

        internal void MouseLeaveEventHandler(int id) {
            throw new NotImplementedException();
        }

        internal void MouseDoubleClickEventHandler(int id) {
            throw new NotImplementedException();
        }
    }
}
