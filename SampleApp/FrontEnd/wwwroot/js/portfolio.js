// Portfolio Interactive JavaScript Helpers

window.portfolio = {
    // Theme Management
    initTheme: function () {
        try {
            var stored = localStorage.getItem("portfolio_theme");
            var isDark = stored ? stored === "dark" : true; // Default to dark for sleek developer portfolio
            document.documentElement.classList.toggle("dark", isDark);
            document.documentElement.setAttribute("data-theme", isDark ? "dark" : "light");
            return isDark ? "dark" : "light";
        } catch (e) {
            return "dark";
        }
    },
    setTheme: function (theme) {
        try {
            var isDark = theme === "dark";
            document.documentElement.classList.toggle("dark", isDark);
            document.documentElement.setAttribute("data-theme", theme);
            localStorage.setItem("portfolio_theme", theme);
        } catch (e) {}
    },
    getTheme: function () {
        return document.documentElement.classList.contains("dark") ? "dark" : "light";
    },

    // Smooth Scrolling
    scrollToElement: function (elementId) {
        var el = document.getElementById(elementId);
        if (el) {
            el.scrollIntoView({ behavior: 'smooth', block: 'start' });
        }
    },
    scrollToTop: function () {
        window.scrollTo({ top: 0, behavior: 'smooth' });
    },

    // Clipboard
    copyText: async function (text) {
        try {
            await navigator.clipboard.writeText(text);
            return true;
        } catch (err) {
            // Fallback
            var textArea = document.createElement("textarea");
            textArea.value = text;
            textArea.style.position = "fixed";
            textArea.style.left = "-9999px";
            document.body.appendChild(textArea);
            textArea.focus();
            textArea.select();
            var successful = document.execCommand('copy');
            document.body.removeChild(textArea);
            return successful;
        }
    },

    // Video Speed Tool
    setVideoSpeed: function (videoElement, rate, preservesPitch) {
        if (!videoElement) return;
        videoElement.playbackRate = rate;
        videoElement.preservesPitch = preservesPitch;
        if (videoElement.mozPreservesPitch !== undefined) {
            videoElement.mozPreservesPitch = preservesPitch;
        }
    },
    stepVideoFrame: function (videoElement, seconds) {
        if (!videoElement) return;
        videoElement.currentTime = Math.max(0, Math.min(videoElement.duration, videoElement.currentTime + seconds));
    },

    // Canvas Photo Collage Tool
    renderCollage: function (canvasElement, img1Data, img2Data, isHorizontal, borderWidth, borderColor, gap, borderRadius) {
        if (!canvasElement || !img1Data || !img2Data) return;

        var img1 = new Image();
        var img2 = new Image();
        var loaded = 0;

        function onBothLoaded() {
            var ctx = canvasElement.getContext('2d');
            
            // Standard target sizing
            var maxDimension = 1200;
            var w1 = img1.naturalWidth || 800;
            var h1 = img1.naturalHeight || 600;
            var w2 = img2.naturalWidth || 800;
            var h2 = img2.naturalHeight || 600;

            var targetCanvasWidth, targetCanvasHeight;
            var draw1X, draw1Y, draw1W, draw1H;
            var draw2X, draw2Y, draw2W, draw2H;

            if (isHorizontal) {
                // Side by side: normalize height to matching h
                var commonH = 800;
                var scale1 = commonH / h1;
                var scale2 = commonH / h2;
                var finalW1 = Math.round(w1 * scale1);
                var finalW2 = Math.round(w2 * scale2);

                targetCanvasWidth = finalW1 + finalW2 + (borderWidth * 2) + gap;
                targetCanvasHeight = commonH + (borderWidth * 2);

                draw1X = borderWidth;
                draw1Y = borderWidth;
                draw1W = finalW1;
                draw1H = commonH;

                draw2X = borderWidth + finalW1 + gap;
                draw2Y = borderWidth;
                draw2W = finalW2;
                draw2H = commonH;
            } else {
                // Stacked vertical: normalize width to matching w
                var commonW = 800;
                var scale1 = commonW / w1;
                var scale2 = commonW / w2;
                var finalH1 = Math.round(h1 * scale1);
                var finalH2 = Math.round(h2 * scale2);

                targetCanvasWidth = commonW + (borderWidth * 2);
                targetCanvasHeight = finalH1 + finalH2 + (borderWidth * 2) + gap;

                draw1X = borderWidth;
                draw1Y = borderWidth;
                draw1W = commonW;
                draw1H = finalH1;

                draw2X = borderWidth;
                draw2Y = borderWidth + finalH1 + gap;
                draw2W = commonW;
                draw2H = finalH2;
            }

            canvasElement.width = targetCanvasWidth;
            canvasElement.height = targetCanvasHeight;

            // Fill Background / Border Color
            ctx.fillStyle = borderColor || "#18181b";
            ctx.fillRect(0, 0, targetCanvasWidth, targetCanvasHeight);

            // Draw Images with optional rounded clip
            function drawImageWithRounded(img, x, y, w, h, radius) {
                ctx.save();
                if (radius > 0) {
                    ctx.beginPath();
                    ctx.moveTo(x + radius, y);
                    ctx.lineTo(x + w - radius, y);
                    ctx.quadraticCurveTo(x + w, y, x + w, y + radius);
                    ctx.lineTo(x + w, y + h - radius);
                    ctx.quadraticCurveTo(x + w, y + h, x + w - radius, y + h);
                    ctx.lineTo(x + radius, y + h);
                    ctx.quadraticCurveTo(x, y + h, x, y + h - radius);
                    ctx.lineTo(x, y + radius);
                    ctx.quadraticCurveTo(x, y, x + radius, y);
                    ctx.closePath();
                    ctx.clip();
                }
                ctx.drawImage(img, x, y, w, h);
                ctx.restore();
            }

            drawImageWithRounded(img1, draw1X, draw1Y, draw1W, draw1H, borderRadius);
            drawImageWithRounded(img2, draw2X, draw2Y, draw2W, draw2H, borderRadius);
        }

        img1.onload = function() {
            loaded++;
            if (loaded === 2) onBothLoaded();
        };
        img2.onload = function() {
            loaded++;
            if (loaded === 2) onBothLoaded();
        };

        img1.src = img1Data;
        img2.src = img2Data;
    },

    downloadCanvas: function (canvasElement, fileName) {
        if (!canvasElement) return;
        var link = document.createElement('a');
        link.download = fileName || 'collage-aliraza-codes.png';
        link.href = canvasElement.toDataURL('image/png');
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
};
